<?php


if(have_posts()) :
  while (have_posts()): the_post();
    
	get_template_part('content');
	
  endwhile; 
else :
  echo"No thing found!";
  
endif;

?> 

<?php 

?>