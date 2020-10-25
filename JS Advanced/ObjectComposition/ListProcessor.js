function solve(input) {
    const listProcessorBuilder = function () {
        let result = [];
        return {
            add: text => result = [...result, text],
            remove: element => result = result.filter(x => x != element),
            print: () => console.log(result.join()),
        };
    }

    let listProcessor = listProcessorBuilder();

    input.map(x => x.split(' '))
        .forEach(([cmd, arg]) => {
            listProcessor[cmd](arg)
        });
}