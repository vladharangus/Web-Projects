$(document).ready(function(){

  $(".tab").css({
    'overflow': 'hidden',
    'border': '1px solid #ccc',
    'background-color': '#f1f1f1'
  });

  $(".tab button").css({
    'background-color': 'inherit',
    'float': 'left',
    'border': 'none',
    'outline': 'none',
    'cursor' : 'pointer',
    'padding': '14px 16px',
    'transition': '0.3s',
    'font-size': '17px'
  });


  $(".tabcontent").css({
    'display' : 'none',
    'padding': '6px 12px',
    'border': '1px solid #ccc',
    'border-top': 'none',
  });

  $(".img").css({
    'width' : '100px',
    'height' : '100px'
  });

  $(".tab button").hover(function() {
      $(this).css("background-color","#ddd")},
     function(){ $(this).css("background-color","#f1f1f1")
  });

  $(".tab button").click(function () {
    index = $(this).index();
    $(".tabcontent").hide();
    $(".tabcontent").eq(index).show();
  })


}) ;
