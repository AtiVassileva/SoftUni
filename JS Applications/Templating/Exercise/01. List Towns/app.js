const htmlSelectors = {
    'loadBtn': () => document.getElementById('btnLoadTowns'),
    'citiesRoot': () => document.getElementById('root'),
    'townsInput': () => document.getElementById('towns'),
}

htmlSelectors['loadBtn']().addEventListener('click', (e) => {
    e.preventDefault();
    let cities = htmlSelectors['townsInput']().value.split(/[, ]+/g)
        .map(city => {
            return { name: city }
        });

    getTemplate().then(templateSrc => {
        let template = Handlebars.compile(templateSrc);
        htmlSelectors['citiesRoot']().innerHTML = template({ cities });
    });

    htmlSelectors['townsInput']().value = '';
});

async function getTemplate() {
    const response = await fetch('./city-template.hbs');
    return await response.text();
}