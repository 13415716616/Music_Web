$(function(){
	//浏览器窗口发生改变的时候调用just方法
	window.onresize=just;
	//计算高度以及行高方法
	function just(){
		$("body").height($(window).height());
		$(".footer_left,.footer_right").css("line-height",$("footer").outerHeight()+"px");
		$(".box_Lyric").height(($(".Text_right").outerHeight()-284)+"px");
		$(".left_song,.left_singer,.left_time").css("line-height",$(".left_title").outerHeight()+"px");
		cstumScroll('scroll_bar','bar','menu','menu_ul',$("#menu").outerHeight());
		if($("	.box_Lyric").outerHeight()<240){
			Trq.row=2;
		}else{
			Trq.row=4;
		}
	}
	just();
	
	//播放按钮
	$("#plays").click(function(){
		if($(this).hasClass("fa-play")==true){
			$("#musicplay")[0].play();
			$(this).removeClass("fa-play").addClass("fa-pause");
		}else{
			$("#musicplay")[0].pause();
			$(this).removeClass("fa-pause").addClass("fa-play");
		}
	});
	
	 var onOff=false;
	 //进度条
	 $(".li_slider,.li_Percentage").click(function(e){
		$(".li_Percentage").css("width",Math.ceil((e.pageX-$(".li_slider").offset().left)/$(".li_slider").outerWidth()*100)+"%");
		$("#musicplay")[0].currentTime=parseInt($(".li_Percentage").outerWidth()/$(".li_slider").outerWidth()*$("#musicplay")[0].duration);
 		higHeight($("#musicplay")[0].currentTime);
	 });
	$(".li_slider,.li_Percentage").mousedown(function(e){
		onOff=true;
		$(document).mousemove(function(e){
			if(onOff==true){
				if(e.pageX-$(".li_slider").offset().left<=$(".li_slider").outerWidth() && e.pageX-$(".li_slider").offset().left>=0){
					$(".li_Percentage").css("width",Math.ceil((e.pageX-$(".li_slider").offset().left)/$(".li_slider").outerWidth()*100)+"%");
						$("#musicplay")[0].currentTime=parseInt($(".li_Percentage").outerWidth()/$(".li_slider").outerWidth()*$("#musicplay")[0].duration);
						higHeight($("#musicplay")[0].currentTime);
				}
			}
		});
		$(document).mouseup(function(){
			onOff=false;
		});
	});
	//音量条
	$(".volume_box,.volume_slider").click(function(e){
		$(".volume_slider").css("width",Math.ceil((e.pageX-$(".volume_box").offset().left)/$(".volume_box").outerWidth()*100)+"%");
		$("#musicplay")[0].volume=($(".volume_slider").outerWidth()/$(".volume_box").outerWidth());
	});
	$(".volume_box,.volume_slider").mousedown(function(e){
		onOff=true;
		$(document).mousemove(function(e){
			if(onOff==true){
				if(e.pageX-$(".volume_box").offset().left<=$(".volume_box").outerWidth() && e.pageX-$(".volume_box").offset().left>=0){
					$(".volume_slider").css("width",Math.ceil((e.pageX-$(".volume_box").offset().left)/$(".volume_box").outerWidth()*100)+"%");
				}
			}
		});
		$(document).mouseup(function(e){
			onOff=false;
			$("#musicplay")[0].volume=($(".volume_slider").outerWidth()/$(".volume_box").outerWidth());
		});
	});
	var vnum;
	var vwidth;
	//点击关闭音量
	$("#footer_volume").click(function(){
		if($(this).hasClass('fa-volume-up')==true){
			vnum=$("#musicplay")[0].volume;
			vwidth=$(".volume_slider").outerWidth();
			$(this).removeClass('fa-volume-up').addClass('fa-volume-off');
			$('.volume_slider').css("width","0%");
			$("#musicplay")[0].volume=0;
		}else{
			$(this).removeClass('fa-volume-off').addClass('fa-volume-up');
			$("#musicplay")[0].volume=vnum;
			$('.volume_slider').css("width",vwidth);
		}
	});
	
	//点击选中
	$(".circle").click(function(){
		if($(this).hasClass("circleclick")==false){
			$(this).addClass("circleclick");
		}else{
			$(this).removeClass("circleclick");
		}
	});
	
	//点击播放模式
	$("#footer_pattern").click(function(){
		if($(this).hasClass("fa-retweet")==true){
			$(this).addClass("fa-random").removeClass("fa-retweet");
			$(this).attr("title","随机播放");
			Trq.random=2;
		}else{
			$(this).addClass("fa-retweet").removeClass("fa-random");
			$(this).attr("title","循环播放");
			Trq.random=1;
		}
	});
	
	$("#footer_pattern").hover(function(){
		if($(this).hasClass("fa-retweet")==true){
			$(this).attr("title","循环播放");
		}else{
			$(this).attr("title","随机播放");
		}
	})
});
