function getArticleGenerator(articles) {
    let content = document.getElementById('content');

    function showNext(){
        let info = articles.shift();

        if (info) {
            let divElement = document.createElement('article');
            divElement.textContent = info;
            content.appendChild(divElement);
        }
    }
    return showNext;
}