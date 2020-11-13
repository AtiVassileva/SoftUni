let monkeysDiv = document.querySelector('.monkeys');

getTemplate('./monkey-template.hbs')
    .then(templateSrc => {
        let template = Handlebars.compile(templateSrc);
        monkeysDiv.innerHTML = template({monkeys});
        showInformationAboutMonkey();
    });

function showInformationAboutMonkey() {
Array.from(monkeysDiv.querySelectorAll('.monkey button'))
.map(btn => btn.addEventListener('click', () => {
    let paragraphInfo = btn.parentElement.children[3];
    paragraphInfo.style.display = paragraphInfo.style.display == 'none' ? 'block' : 'none';
    btn.textContent = btn.textContent == 'Info' ? 'Hide' : 'Info';
}))

}
async function getTemplate(templatePath) {
    const response = await fetch(templatePath);
    return await response.text();
}