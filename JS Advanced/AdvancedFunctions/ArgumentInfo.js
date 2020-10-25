function solve() {
    let result = [];
    let dict = {};

    [...arguments].forEach(element => {
        let type = typeof element;

        result.push({ type, value: element });

        if (!dict[type]) {
            dict[type] = 0;
        }

        dict[type]++;
    });

    result.forEach(x => console.log(`${x.type}: ${x.value}`));
    let sort = Object.entries(dict).sort((a, b) => b[1] - a[1]);
    sort.forEach(el => console.log(`${el[0]} = ${el[1]}`))
}