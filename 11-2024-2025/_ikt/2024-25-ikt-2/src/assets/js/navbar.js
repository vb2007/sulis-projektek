const navToggler = document.querySelector('.nav--toggler');
const navCollapse = document.querySelector('.nav--collapse');
const navWrapper = document.querySelector('.nav--wrapper');

navToggler.addEventListener('click', () => {
    navCollapse.classList.toggle('show');
    navWrapper.classList.toggle('show');
});