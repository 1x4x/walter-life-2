$(window).on("load", function () {
   // Preload
   $("#preload").fadeOut(500);
});


jQuery(document).ready(function(){


// Isotope Courses
   var $grid = $('.grid').isotope({
      itemSelector: '.element-item',
      layoutMode: 'fitRows'
   });


   $('.filter a').on('click', function (event) {
        event.preventDefault();
      var value = $(this).attr('data-name');
      $grid.isotope({
         filter: value
      });

      $('.filter a').removeClass('active-tabs');
      $(this).addClass('active-tabs');

   });


 // Coach owlCarousel
  $('.coach-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:false,
    dots: true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        850: {
            items:3
        },
        1000:{
            items:3
        }
    }
});


// Gallery magnificPopup
  $('.popup-gallery').magnificPopup({
        delegate: 'a',
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        mainClass: 'mfp-img-mobile',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0,1] // Will preload 0 - before current, and 1 after the current image
        },
        image: {
            tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
            titleSrc: function(item) {
                return item.el.attr('title') + '<small>by Marsel Van Oosten</small>';
            }
        }
    });


// Testimonials owlCarousel
  $('.testimonials-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:false,
    dots: true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:2
        }
    }
});


// Mobile menu
   var openMenu = $('#openmenu');
   var closeMenu = $('#closemenu');
   var navigation = $('.header-menu');

    openMenu.click(function (event) {
      event.preventDefault();
      navigation.animate({
         'left': '0px'
      }, 800);

   });

   closeMenu.click(function (event) {
      event.preventDefault();
      navigation.animate({
         'left': '-320px'
      }, 800);
   });


// Scroll Top Button
   $('#btn-top').click(function () {
      $('body,html').animate({
         scrollTop: 0
      }, 800);
      return false;
   });

   $('#btn-top').hide();
   $(window).scroll(function () {
      if ($(this).scrollTop() > 50) {
         $('#btn-top').fadeIn();
      } else {
         $('#btn-top').fadeOut();
      }
   });


// Scroll Menu
   $(".menu").on("click", "a", function (event) {
      event.preventDefault();
      var id = $(this).attr('href');
      var top = $(id).offset().top;
      $('body,html').animate({
         scrollTop: top
      }, 1500);
   });
   $("#logo, .subscription").on("click", function (event) {
      event.preventDefault();
      var id = $(this).attr('href');
      var top = $(id).offset().top;
      $('body,html').animate({
         scrollTop: top
      }, 1500);
   });

   $(".menu li a, #logo, .subscription").on("click", function (event) {
      event.preventDefault();
      navigation.animate({
         'left': '-320px'
      }, 800);
   });

// Send ajax form
   $('#submit-registration').click(function(event){
      event.preventDefault();
      var name = $('input[name="name"]').val();
      var surname = $('input[name="surname"]').val();
      var email = $('input[name="email"]').val();
      var subject = $('input[name="subject"]').val();
      var message = $('textarea[name="message"]').val();

      if (name == '' || surname == '' || email == '' || subject == '' || message == '') {
         $('.res').fadeIn().html('<span class="error">All fields must be filled.</span>');
         $('input, textarea').focus(function () {
            $('.res').fadeOut();
         });
      }
      else {
         $.ajax({
            url: '../subscription.php',
            type: 'POST',
            data: {
               name: name,
               surname: surname,
               email: email,
               subject: subject,
               message: message
            },
            dataType: 'html',
            success: function (data) {
               if (data == 'Send') {
                  $('.res').fadeIn().html('<span class="send">Thanks. We will contact you shortly.</span>');

                  $('input[name="name"]').val('');
                  $('input[name="surname"]').val('');
                  $('input[name="email"]').val('');
                  $('input[name="subject"]').val('');
                  $('textarea[name="message"]').val('');

               }
            }

         });

      }

   });


}); // ready