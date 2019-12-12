const body = document.body;
const btn = document.getElementById('nav-button');

btn.addEventListener('click', _ => body.classList.toggle('show'));

// Prevents the focus state from activating on mousedown but
// keeps the focus state for keyboard users
btn.addEventListener('mousedown', (e) => { e.preventDefault() });