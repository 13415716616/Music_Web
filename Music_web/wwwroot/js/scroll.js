//scrollBody：滚动条的整体的id,div#id；scrollBlock：滚动滑块的id,div#id；divBox:内容显示区域的id,div#id，cntList：实际内容的id,div#id;

function cstumScroll(scrollBody,scrollBlock,divBox,cntList,wH=window.innerHeight){
	
	if($("#menu_ul").outerHeight()<$("#menu").outerHeight()){
		$("#scroll_bar").css("display","none");
		$("#menu_ul").css("top","0");
	}
    const div1 = document.getElementById(scrollBody);
    const div2 = document.getElementById(scrollBlock);
    const div3 = document.getElementById(divBox);
    const txt = document.getElementById(cntList);
//  div1.style.height= div3.style.height = wH + 'px';
    //div1.style.height = div3.style.height = box.offsetHeight + 'px';
    div2H = div1.offsetHeight*div3.offsetHeight/txt.scrollHeight;
    div2.style.height = div2H + 'px';
    if(div2H < 20){
        div2.style.height = '20px';
    }else{
        div2.style.height = div2H + 'px';
    }
    div2.onmousedown = div3.onmousedown= function(ev){
//      console.log(ev.pageY);
        let disY = ev.pageY - div2.offsetTop;

//      console.log(txt.style.height);

        document.onmousemove = function(ev){
            let t = ev.pageY - disY;

            if(t < 0){
                t = 0;
            }else if(t > div1.clientHeight - div2.clientHeight){
                t = div1.clientHeight - div2.clientHeight;
            }

            /*
                核心就是这个比例
            */
            let scale = t /  (div1.clientHeight - div2.clientHeight);
            
            txt.style.top =  scale *  (div3.offsetHeight - txt.scrollHeight) + 'px';
            div2.style.top = t + 'px';
        }
        document.onmouseup = function(){
            document.onmousemove = document.onmouseup = null;
        }
        return false;
    }
    addWheel(div1,function(o){
        let t = div2.offsetTop;
        if(o){
            t -= 5;
        }else{
            t += 5;
        }
        if(t < 0){
            t = 0;
        }else if(t > div1.clientHeight - div2.clientHeight){
            t = div1.clientHeight - div2.clientHeight;
        }
        let scale = t /  (div1.clientHeight - div2.clientHeight);
        txt.style.top =  scale *  (div3.offsetHeight - txt.scrollHeight) + 'px';
        div2.style.top = t + 'px';
    });


    function addWheel(obj,fn){
        obj.addEventListener('mousewheel',callback);
        obj.addEventListener('DOMMouseScroll',callback);

        function callback(ev){
            let o = true; //向上
            if(ev.wheelDelta){
                o = ev.wheelDelta > 0?true:false;
            }else{
                o = ev.detail < 0? true:false;
            }
            fn && fn(o);
            ev.preventDefault();
        }
    }
}

