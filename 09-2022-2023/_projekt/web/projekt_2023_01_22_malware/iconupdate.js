// Jelenlegi ikon eltárolása
var current = 0;
var icons = ['https://img.icons8.com/external-mixed-line-solid-yogi-aprelliyanto/512/external-malware-coding-and-programming-mixed-line-solid-yogi-aprelliyanto.png', 'https://img.icons8.com/external-basic-line-gradient-yogi-aprelliyanto/512/external-malware-coding-and-programming-basic-line-gradient-yogi-aprelliyanto.png'];
// Ikno cseréje/frissítése fél másodpercenként
setInterval(function () {
    // Következő ikon beolvasása
    var icon = (++current % icons.length);
    // Ikon linkjének megragadása
    var url = icons[icon];
    // Elemek frissítése
    document.getElementById('icon-a').href = url;
    document.getElementById('icon-b').href = url;
}, 500);