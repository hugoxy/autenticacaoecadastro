const btnMobile = document.querySelector('#hamburger');
function toogleMenu() {
    const nav = document.querySelector('nav');
    const footer = document.querySelector('footer')
    nav.classList.toggle('active');
    document.body.classList.toggle('opened-menu')
    footer.classList.toggle('hide')
}

btnMobile.addEventListener('click', toogleMenu);