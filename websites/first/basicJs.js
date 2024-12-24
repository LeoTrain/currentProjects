document.addEventListener('DOMContentLoaded', () => {
    // Ajout d'un événement au clic sur les liens de navigation
    const navLinks = document.querySelectorAll('header nav ul li a');

    navLinks.forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault();
            const sectionId = link.getAttribute('href').substring(1);
            const section = document.getElementById(sectionId);

            if (section) {
                section.scrollIntoView({ behavior: 'smooth' });
            }
        });
    });

    // Exemple d'ajout de contenu dynamique
    const featuresSection = document.getElementById('features');
    const dynamicContent = document.createElement('p');
    dynamicContent.textContent = 'Ce texte a été ajouté dynamiquement avec JavaScript !';
    featuresSection.appendChild(dynamicContent);

    // Images
    let index = 0;
    const slides = document.querySelectorAll('.slide');
    const prevButton = document.querySelector('.previous');
    const nextButton = document.querySelector('.next');

    function showSlide(n) {
        if (n >= slides.length) index = 0;
        if (n < 0) index = slides.length - 1;
        slides.forEach((slide, i) => {
            slide.style.display = i === index ? 'block' : 'none';
        });
    }

    nextButton.addEventListener('click', () => {
        index++;
        showSlide(index);
    });

    prevButton.addEventListener('click', () => {
        index--;
        showSlide(index);
    });

    showSlide(index);

    const elements = document.querySelectorAll('.fade-in');

    function checkVisibility() {
        elements.forEach(element => {
            if (element.getBoundingClientRect().top < window.innerHeight) {
                element.classList.add('visible');
            }
        });
    }

    window.addEventListener('scroll', checkVisibility);
    checkVisibility(); // Pour les éléments déjà visibles

    // Navbar
    const navbar = document.getElementById('navbar');
    window.onscroll = () => {
        if (window.scrollY > 50) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
    };

});

