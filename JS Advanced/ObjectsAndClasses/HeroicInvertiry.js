function heroicInvertory(input){

    let result = [];

    for (const row of input) {
        let [name, level, items] = row.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        let hero = {name, level, items};

        result.push(hero);
    }

    console.log(JSON.stringify(result));
}