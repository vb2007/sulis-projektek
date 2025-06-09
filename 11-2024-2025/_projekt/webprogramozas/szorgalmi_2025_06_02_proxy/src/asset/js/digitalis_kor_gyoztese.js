document.addEventListener('DOMContentLoaded', () => {
    const creatorElement = document.querySelector('.creator-name');
    if (!creatorElement) return;

    const zutyiPopup = () => {
        const overlay = document.createElement('div');
        overlay.className = 'zutyi-overlay';
        
        const image = document.createElement('img');
        image.className = 'zutyi-img';
        image.src = './asset/img/digitalis_kor_gyoztese.jpg';
        image.alt = 'Digitális kor győztese';
        
        const audio = document.createElement('audio');
        audio.src = './asset/aud/a_sunyoba.wav';
        
        overlay.append(image);
        document.body.append(overlay);
        
        overlay.offsetHeight;
        overlay.classList.add('visible');
        
        audio.play();
        
        audio.onended = () => {
            overlay.classList.remove('visible');
            
            setTimeout(() => {
                document.body.removeChild(overlay);
            }, 500);
        };
    }

    creatorElement.addEventListener('click', zutyiPopup);
});
