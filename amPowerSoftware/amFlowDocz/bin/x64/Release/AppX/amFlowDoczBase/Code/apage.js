//using albert.js


function HideMobileNavBar() {
	a_Hide("mobilenav");
}


function ShowHideMobileNavBar() {
	a_ShowHide("mobiblenav");
}


//Preload Lamba
//window.addEventListener("load",function()
//    {
//var gets the id of the preload 
//     var id = document.getElementById("load_screen");
//removes on load 
//   document.body.removeChild(id);

// });

a_Event("mnuMain", "click", ShowHideMobileNavBar);
a_Event("maincontent", "click", HideMobileNavBar);
