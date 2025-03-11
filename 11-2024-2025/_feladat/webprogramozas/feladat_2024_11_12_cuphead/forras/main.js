const buttons = [...document.querySelectorAll('.levels-button')];
const articles = [...document.querySelectorAll('.levels-data')];

for (const link of buttons) {
    link.addEventListener('click', () => {
        for (const article of articles) {
            article.classList.add('hide');
        }
        for (const button of buttons) {
            button.classList.remove('selected')
        }
        link.classList.add('selected')
        articles.find(x => x.id == link.id.split('-')[0])
            .classList.remove('hide');
    })
}