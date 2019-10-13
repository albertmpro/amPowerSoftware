
// A quick shortcut for the document element 
function a(id)
{
  return document.getElementById(id);
}

// Quick shortcut for document style 
function astyle(id)
{
 return document.getElementById(id).style;
}


//Designed to capture POST ajax call
function a_POST(_url,id,vars,loadMessage)
{
	var ajax
	if (window.XMLHttpRequest)
	{
		// code for IE7+, Firefox, Chrome, Opera, Safari
		ajax= new XMLHttpRequest();
	}
	else
	{
		// code for IE6, IE5(Please stop using these browsers, they are not safe!)
		ajax=new ActiveXObject("Microsoft.XMLHTTP");
	}
    
    ajax.open("POST", _url, true);

    // Set content type header information for sending url encoded variables in the request
    ajax.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    
    ajax.onreadystatechange = function() 
    {
    	if (ajax.readyState == 4 && ajax.status == 200)
        {
		    var return_data = ajax.responseText;

			document.getElementById(id).innerHTML = return_data;
	    }
    }

	if(vars != null)
	{

		ajax.send(vars);
		if(loadMessage !=null)
		{
			a(id).innerHTML = loadMessage;
		}
		return ajax;
	}	
    return ajax;
}
//Designed to capture GET ajax call
function a_GET(id,_file)
{
	var ajax
	if (window.XMLHttpRequest)
	{
		// code for IE7+, Firefox, Chrome, Opera, Safari
		ajax= new XMLHttpRequest();
	}
	else
	{
		// code for IE6, IE5(Please stop using these browsers, they are not safe!)
		ajax=new ActiveXObject("Microsoft.XMLHTTP");
	}

	ajax.onreadystatechange=function()
	{
		if (ajax.readyState==4 && ajax.status==200)
		{
			document.getElementById(id).innerHTML=ajax.responseText;
		}
	}
	
	if(_file != null)
	{
		ajax.open("GET",_file,true);
		ajax.send();
		
	}
	return ajax;

}

//Quick shortcut for spiting out html to an id
function ahtml(id,spit){
  
  a(id).innerHTML += spit;
}
//Qucik way to do a click event 
function aclick(id,event)
{
    a(id).addEventListener("click",event);
    
}


// foreach function to mimic a foreach statement 
function forEach(array,e)
{
    for (var i = 0; i < array.length; i++){
	//Execute the function 
    e(array[i]);    }
}

//Hide and show function 
function ashowhide(id)
{
 
  
  if(astyle(id).display == "block")
    {
      astyle(id).display = "none";
    }
  else
    {
      astyle(id).display = "block";
      
    }
      
    
}


