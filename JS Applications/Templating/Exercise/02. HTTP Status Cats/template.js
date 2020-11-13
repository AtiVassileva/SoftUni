let allCatsSection = document.getElementById('allCats');

Promise.all([
    getTemplate('./cats-template.hbs'),
    getTemplate('./cat.hbs')
]).then(([templateSrc, catSrc]) => {
    Handlebars.registerPartial('cat', catSrc);
    let template = Handlebars.compile(templateSrc);
    allCatsSection.innerHTML = template({ cats });
    showInformationAboutCat();
})

function showInformationAboutCat() {
    Array.from(allCatsSection.querySelectorAll('button'))
    .map(btn => btn.addEventListener('click', () => {
        let statusDiv = btn.parentElement.children[1];
        statusDiv.style.display = statusDiv.style.display == 'none' ? 'block' : 'none';
        btn.textContent = btn.textContent == 'Hide status code' ? 'Show status code' : 'Hide status code';
    }))
}

async function getTemplate(templatePath) {
    const response = await fetch(templatePath);
    return await response.text();
}