<?php 




//Add's a Css File via link tag(should be placed in the header )
function AddCss($file,$media)
{
	?>
	<link rel="stylesheet" type="text/css" media="<?php echo"$media"; // The Name of the Media that is being used ?>" href="<?php echo"$file"; //The name of the file that is being used  ?>" />
	<?php
}

//Add's a JavaScript File 
function AddJavaScript($file)
{
	?>
	<script type="javascript" src="<?php echo"$file"; //The name of the JavaScript File  ?>" </script>
	<?php
}

//Add's a div with a class and some contnet that is a method 
function CDiv($class,$content)
{
   ?>
	
	<div class="" >
		
		<?php $content(); ?>
		
		</div>
	
	<?php 
}











?>