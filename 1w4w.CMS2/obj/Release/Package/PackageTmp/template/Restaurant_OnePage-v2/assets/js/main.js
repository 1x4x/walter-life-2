/***********************************************************
Theme Name:         Restaurant Homepage
/***********************************************************
Theme URI:          https://www.anwahl.de
Author: the         Saeed A. Khokhar
Author URI:         www.anwahl.de
Description:        Theme for ENKHO Holding GmbH
Version:            v 1.0
License:            GNU General Public License v2 or later
License URI:        http://www.gnu.org/licenses/gpl-2.0.html
************************************************************/
    //eMail Senden
    $(document).ready(function () {
      //E-mail Ajax Send
      $("form").submit(function () {
        //Change
        var th = $(this);
        $.ajax({
          type: "POST",
          url: "assets/mail/mail.php",
          //Change
          data: th.serialize()
        }).done(function () {
          UIkit.notification({
            message: 'Form sent successfully!',
            status: 'success',
            pos: 'top-center',
            timeout: 5000
          });
          setTimeout(function () {
            // Done Functions
            th.trigger("reset");
          }, 1000);
        });
        return false;
      });
    });

 //START
document.addEventListener('DOMContentLoaded', () => {
  "use strict";

    // PRELOADER FUNKTION ####################################################################################
    $(window).on('load', function() {
      $('.preloader').delay(100).fadeOut('fast');
    });


    // STICKY HEADER SCROLL  FUNKTION ####################################################################
    const selectHeader = document.querySelector('#header');
    if (selectHeader) {
      // Überwachung des Scroll-Events
      document.addEventListener('scroll', () => {
        // Überprüfen, ob der vertikale Scroll-Wert größer als 100 ist
        if (window.scrollY > 100) {
          selectHeader.classList.add('sticked'); // Hinzufügen der CSS-Klasse "sticked"
        } else {
          selectHeader.classList.remove('sticked'); // Entfernen der CSS-Klasse "sticked"
        }
      });
    }


    // NAVBAR ACTIVE ON SCROLL  FUNKTION #####################################################################
    let navbarlinks = document.querySelectorAll('#navbar a');

    // Funktion zur Aktivierung des aktiven Navigationslinks
    function navbarlinksActive() {
      navbarlinks.forEach(navbarlink => {
        // Überprüfen, ob der Navigationslink eine Hash-Zielangabe hat
        if (!navbarlink.hash) return;

        // Das zugehörige Abschnittselement des Navigationslinks abrufen
        let section = document.querySelector(navbarlink.hash);
        if (!section) return;

        // Aktuelle vertikale Scroll-Position des Fensters mit einem Offset von 200
        let position = window.scrollY + 200;

        // Überprüfen, ob der Navigationslink zum aktuellen Abschnitt gehört
        if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
          navbarlink.classList.add('active'); // Hinzufügen der CSS-Klasse "active"
        } else {
          navbarlink.classList.remove('active'); // Entfernen der CSS-Klasse "active"
        }
      });
    }

    // Aktivierung des aktiven Navigationslinks beim Laden der Seite
    window.addEventListener('load', navbarlinksActive);

    // Aktivierung des aktiven Navigationslinks während des Scrollens
    document.addEventListener('scroll', navbarlinksActive);


    // NAVBAR MOBILE TOOGLE FUNKTION #####################################################################
    // Auswählen des Elements zum Anzeigen der mobilen Navigation
  const mobileNavShow = document.querySelector('.mobile-nav-show');
  // Auswählen des Elements zum Ausblenden der mobilen Navigation
  const mobileNavHide = document.querySelector('.mobile-nav-hide');

  // Hinzufügen eines Klick-Eventlisteners zu allen Elementen mit der Klasse "mobile-nav-toggle"
  document.querySelectorAll('.mobile-nav-toggle').forEach(el => {
    el.addEventListener('click', function(event) {
      event.preventDefault();
      mobileNavToggle();
    });
  });

  // Funktion zum Umschalten der mobilen Navigation
  function mobileNavToggle() {
    // Umschalten der CSS-Klasse "mobile-nav-active" des body-Elements
    document.querySelector('body').classList.toggle('mobile-nav-active');
    // Umschalten der CSS-Klasse "d-none" des Elements zum Anzeigen der mobilen Navigation
    mobileNavShow.classList.toggle('d-none');
    // Umschalten der CSS-Klasse "d-none" des Elements zum Ausblenden der mobilen Navigation
    mobileNavHide.classList.toggle('d-none');
  }

  
    // HIDE NAVBAR MOBILE ON SAM PAGE FUNKTION ###########################################################
      document.querySelectorAll('#navbar a').forEach(navbarlink => {
    // Überprüfen, ob der Navigationslink eine Hash-Zielangabe hat
    if (!navbarlink.hash) return;

    // Das zugehörige Abschnittselement des Navigationslinks abrufen
    let section = document.querySelector(navbarlink.hash);
    if (!section) return;

    // Hinzufügen eines Klick-Eventlisteners zum Navigationslink
    navbarlink.addEventListener('click', () => {
      // Überprüfen, ob die mobile Navigation aktiv ist und bei Klick schließen
      if (document.querySelector('.mobile-nav-active')) {
        mobileNavToggle();
      }
    });
  });

    // DROPDOWN NAVBAR MOBILE FUNKTION #################################################################
    // Auswählen aller Dropdown-Links in der Navigationsleiste
    const navDropdowns = document.querySelectorAll('.navbar .dropdown > a');

    // Hinzufügen eines Klick-Eventlisteners zu jedem Dropdown-Link
    navDropdowns.forEach(el => {
      el.addEventListener('click', function(event) {
        // Überprüfen, ob die mobile Navigation aktiv ist
        if (document.querySelector('.mobile-nav-active')) {
          event.preventDefault(); // Verhindern der Standardaktion des Klicks

          // Umschalten der CSS-Klassen für den aktiven Zustand des Dropdown-Links und des Dropdown-Inhalts
          this.classList.toggle('active');
          this.nextElementSibling.classList.toggle('dropdown-active');

          // Umschalten der CSS-Klassen für den Dropdown-Indikator-Pfeil
          let dropDownIndicator = this.querySelector('.dropdown-indicator');
          dropDownIndicator.classList.toggle('bi-chevron-up');
          dropDownIndicator.classList.toggle('bi-chevron-down');
        }
      });
    });

    // BACK TO TOP FUNKTION ############################################################################
    // Auswählen des Scroll-Top-Elements
    const scrollTop = document.querySelector('.back-to-top');
    if (scrollTop) {
      // Funktion zum Aktivieren/Deaktivieren des Scroll-Top-Elements basierend auf dem Scroll-Verhalten
      const toggleScrollTop = function() {
        window.scrollY > 100 ? scrollTop.classList.add('active') : scrollTop.classList.remove('active');
      };

      // Aktivieren/Deaktivieren des Scroll-Top-Elements beim Laden der Seite
      window.addEventListener('load', toggleScrollTop);

      // Aktivieren/Deaktivieren des Scroll-Top-Elements während des Scrollens
      document.addEventListener('scroll', toggleScrollTop);

      // Scrollen zur oberen Position der Seite beim Klicken auf das Scroll-Top-Element
      scrollTop.addEventListener('click', function() {
        window.scrollTo({
          top: 0,
          behavior: 'smooth'
        });
      });
    }
  
    // EINBINDUNG DER G-LIGHTBOX FUNKTION ###############################################################
    const glightbox = GLightbox({
     selector: '.glightbox'
   }); 
   
  
    // EINBINDUNG DER PURECOUNTER FUNKTION ##############################################################
    new PureCounter();
    
    

    // HOME SLIDER js FUNKTION #######################################################################
    $('#slider-carousel').owlCarousel({
        loop: true,
        items: 1,
        rewind: true,
        fade: true,
        nav: false,
        navText : ['<i class="bi bi-arrow-left-short"></i>','<i class="bi bi-arrow-right-short"></i>'],
        dots: false,
        animateOut: 'fadeOut',
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1,
                nav: false,
                dots: true
            },
            479: {
                items: 1,
                nav: false,
                dots: true
            },
            540: {
                items: 1,
                nav: false,
                dots: true
            },
            768: {
                items: 1
            },
            979: {
                items: 1
            },
            1199: {
                items: 1
            }
        }
    });

    // AOS FUNKTION #######################################################################
    // Funktion zum Initialisieren von AOS (Animate On Scroll)
    function aos_init() {
      AOS.init({
        duration: 1000, // Dauer der Animation (in Millisekunden)
        easing: 'ease-in-out', // Easing-Funktion für die Animation
        once: true, // Animation nur einmal abspielen
        mirror: false // Elemente nicht spiegeln, wenn sie aus dem Sichtfeld verschwinden und wieder auftauchen
      });
    }

    // Event-Listener für das Laden der Seite
    window.addEventListener('load', () => {
      aos_init(); // Aufrufen der Funktion zur Initialisierung von AOS
    });
    
});