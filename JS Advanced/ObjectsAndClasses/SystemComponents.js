function solve(input) {
    let result = {};

    input.forEach(line => {
        let [systemName, component, subComponent] = line.split(' | ');

        if (!result[systemName]) {
            result[systemName] = {};
        }

        if (!result[systemName][component]) {
            result[systemName][component] = [];
        }

        result[systemName][component].push(subComponent);
    });

    Object.entries(result).sort((curr, next) => {
        return Object.entries(next[1]).length - Object.entries(curr[1]).length
            || curr[0].localeCompare(next[0])
    }).forEach(([system, components]) => {
        console.log(system);
        Object.entries(components).sort((curr, next) => {
            return next[1].length - curr[1].length;
        }).forEach(([component, sub]) => {
            console.log(`|||${component}`);
            sub.forEach(sb => console.log(`||||||${sb}`));
        });
    });
}