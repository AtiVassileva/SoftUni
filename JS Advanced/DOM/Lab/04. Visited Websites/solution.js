function solve() {
    let linkElements = document.querySelectorAll('.link-1 a');

    for (const link of linkElements) {
        link.addEventListener('click', onlinkElementClick)

    }

    function onlinkElementClick(e) {
        let paragraph = e.currentTarget.nextElementSibling;
        let visitedCount = Number(paragraph.innerText.split(' ')[1]);

        visitedCount++;

        paragraph.innerText = `visited ${visitedCount} times`;

    }
}