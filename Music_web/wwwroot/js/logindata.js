var Trq={
	timesA : "",
	upDate_num : 0,
	idAry:[],
	volume:0.5,  //初始音量值
	random:1,//播放模式 1->循环  2->随机
	row:3
}
//加载数据
function lodingdatas(){
	var music_str="";
	var Arrys=Array.from(data);
	Arrys.forEach((e,i)=>{
		if(e.like==true){
			music_str+='<li ids='+(e.id-1)+'><div class="circle"></div><span>'+e.song+'</span><span>'+e.singer.name+'</span><span>'+e.time+'</span></li>';
			Trq.idAry.push(e.id-1);
		}
	});
	$("#menu_ul").html(music_str);
	upDateSong(Trq.idAry[0],Trq.volume);
	$(document).keydown(function(e){
		if(e.keyCode==32){
			if($("#plays").hasClass("fa-play")==true){
				$("#musicplay")[0].play();
				$("#plays").removeClass("fa-play").addClass("fa-pause");
			}else{
				$("#musicplay")[0].pause();
				$("#plays").removeClass("fa-pause").addClass("fa-play");
			}
		}
	})
}
//双击加载对应数据并进行播放
function dbclicks(){
	$("#menu_ul").on('dblclick',function(e){
		if($(e.target).parent()[0].tagName.toLowerCase()=="li"){
			//重置歌词
			$("#Lyric").css('top',"0px");
			//li的id
			var ids=$(e.target).parent().attr('ids');
			upDateSong(ids,$("#musicplay")[0].volume);
			if($("#plays").hasClass("fa-play")==true){
				$("#plays").removeClass("fa-play").addClass("fa-pause");
			}
		}
		e.stopPropagation();
	});
}
//监听播放进度
$("#musicplay").on('timeupdate',function(e){
	//计算进度条行走值
	Trq.upDate_num=(($("#musicplay")[0].currentTime/$("#musicplay")[0].duration)*100).toFixed(1);
	//进度条
	if(Trq.upDate_num>=100){
		$(".li_Percentage").css("width","100%");
	}else{
		$(".li_Percentage").css("width",Trq.upDate_num+"%");
	}
	//播放时间
	$(".information_time").text(secondToMin($("#musicplay")[0].currentTime)+"/"+secondToMin($("#musicplay")[0].duration));
	if($("#musicplay")[0].currentTime!=0){
		higHeight($("#musicplay")[0].currentTime,Trq.row);
	}else{
		$(".information_time").text("");
	}
});
//监听播放结束
$("#musicplay").on("ended",function(){
	if(Trq.random==1){
		var animation=document.querySelectorAll(".menu_animation");
		if(animation[0].parentElement.nextElementSibling){
			upDateSong($(animation[0].parentElement.nextElementSibling).attr("ids"),$("#musicplay")[0].volume);
		}else{
			upDateSong($(document.getElementById("menu_ul").children[0]).attr("ids"),$("#musicplay")[0].volume);
		}
	}
	if(Trq.random==2){
		randoms();
	}
});
//点击下一首
$("#footer_next").click(function(){
	if($("#menu_ul").find("span").hasClass("Oh_dear")==false){
		if(Trq.random==1){
			var animation=document.querySelectorAll(".menu_animation");
			if(animation[0].parentElement.nextElementSibling){
				upDateSong($(animation[0].parentElement.nextElementSibling).attr("ids"),$("#musicplay")[0].volume);
			}else{
				upDateSong($(document.getElementById("menu_ul").children[0]).attr("ids"),$("#musicplay")[0].volume);
			}
		}
		if(Trq.random==2){
			randoms();
		}
	}
});
//点击上一首
$("#footer_last").click(function(){
	if($("#menu_ul").find("span").hasClass("Oh_dear")==false){
		if(Trq.random==1){
			var animation=document.querySelectorAll(".menu_animation");
			if(animation[0].parentElement.previousElementSibling){
				upDateSong($(animation[0].parentElement.previousElementSibling).attr("ids"),$("#musicplay")[0].volume);
			}else{
				upDateSong($(document.getElementById("menu_ul").children[document.getElementById("menu_ul").children.length-1]).attr("ids"),$("#musicplay")[0].volume);
			}
		}
		if(Trq.random==2){
			randoms();
		}
	}
});
//随机方法
function randoms(){
	//随机取一个数组的值
	var ran = Math.floor(Math.random() * Trq.idAry.length);
	upDateSong(Trq.idAry[ran],$("#musicplay")[0].volume);
}
//更新方法
function upDateSong(sub,volumes,deles){
	var lis=document.querySelectorAll("#menu_ul li");
	//高亮
	if(deles==1){
		$("#menu_ul li").eq(0).css("color","#DBC183").siblings().css("color","#AD986D");
		$("#menu_ul li").eq(0).append('<div class="menu_animation"><em class="anim_1"></em><em class="anim_2"></em><em class="anim_3"></em></div>').siblings().find(".menu_animation").remove();
	}else{
		for(var k=0;k<lis.length;k++){
			if(lis[k].getAttribute("ids")==sub){
				$(lis[k]).css("color","#DBC183").siblings().css("color","#AD986D");
				$(lis[k]).append('<div class="menu_animation"><em class="anim_1"></em><em class="anim_2"></em><em class="anim_3"></em></div>').siblings().find(".menu_animation").remove();
			}
		}
	}
	//音量
	$("#musicplay")[0].volume=volumes;
	//重置歌词
	$("#Lyric").css('top',"0px");
	//更换路径
	$("#musicplay").attr({"src":data[sub].src,"ids":sub});
	//重置进度条
	$(".li_Percentage").css("width","0%");
	//播放
	$("#musicplay")[0].play();
	//更新歌名
	$(".information_name").text(data[sub].song+"-"+data[sub].singer.name);
	//更新歌词
	Trq.timesA=lyricsMethod(data[sub].words);
	//更改海报头像
	$(".right_frame img").attr("src",data[sub].singer.photo);
	//更改大背景图
	$(".blur").css("background-image",'url('+data[sub].singer.photo+')');
}

//歌词高亮方法
function higHeight(times,rows){
	Trq.timesA.forEach((e,i)=>{
		if(parseInt(times)==parseInt(e)){
			$("#Lyric li").eq(i).addClass("Highlight").siblings().removeClass("Highlight");
			if(i>rows){
				$("#Lyric").css('top',"-"+(i-rows)*32+"px");
			}
		}
	});
}
//歌词切割方法
function lyricsMethod(texts){
	//时间数组
	var Arytimes=new Array();
	//歌词数组
	var Artxt=new Array();
	//按照回车和空格切
	var lysrc=texts.split('\n');
	var str="";
	lysrc.forEach((e,i)=>{
		if(e.split(']')[1]){
			str+='<li>'+e.split(']')[1]+'</li>';
			//时间数组
			Arytimes.push(parseInt(((e.split('[')[1]).split(']')[0]).split(':')[0]*60)+parseInt(((e.split('[')[1]).split(']')[0]).split(':')[1].split('.')[0]));
			//对应歌词
			Artxt.push(e.split(']')[1]);
		}
	});
	$("#Lyric").html(str);
	return Arytimes;
}
//时间计算
function secondToMin(s) {
	var MM = Math.floor(s / 60);
	var SS = s % 60;
	if(MM < 10)
		MM = "0" + MM;
	if(SS < 10)
		SS = "0" + SS;
	var min = MM + ":" + SS;
		return min.split('.')[0];
}
//点击删除的时候
$("#header_delete").click(function(){
	if($("#menu_ul").find("span").hasClass("Oh_dear")==false){
		var clicks=document.querySelectorAll(".circleclick");
		for(var i=0;i<clicks.length;i++){
			clicks[i].parentElement.remove();
			for(var j=0;j<Trq.idAry.length;j++){
				if(Trq.idAry[j]==clicks[i].parentElement.getAttribute("ids")){
					Trq.idAry.splice(j,1);
				}
			}
		}
		var lis=document.querySelectorAll("#menu_ul li");
		if(lis.length==0){
			$("#musicplay").attr("src","");
			$(".blur").css("background-image","url(img/123.gif)");
			$(".right_frame img").attr("src","img/123.gif");
			$("#menu_ul").html("<span class='Oh_dear'>哎呀，没有歌曲啦！</span>");
			$("#plays").removeClass("fa-pause").addClass("fa-play");
			$("#Lyric,.information_name").html("");
		}else{
			upDateSong(Trq.idAry[0],Trq.volume,1);
		}
		$("#plays").removeClass("fa-play").addClass("fa-pause");
		cstumScroll('scroll_bar','bar','menu','menu_ul',$("#menu").outerHeight());
	}
});
//点击清空列表的时候
$("#header_empty").click(function(){
	$("#menu_ul").html("");
	emptys_delet();
});

//清空方法
function emptys_delet(){
	$("#musicplay").attr("src","");
	$("#plays").removeClass("fa-pause").addClass("fa-play");
	$(".blur").css("background-image","url(img/123.gif)");
	$(".right_frame img").attr("src","img/123.gif");
	$("#Lyric,.information_name").html("");
	$("#menu_ul").html("<span class='Oh_dear'>哎呀，没有歌曲啦！</span>");
}
lodingdatas();
dbclicks();
