function addRemoveElements(commands){

    let result = [];
    let counter = 1;

    commands.forEach(command => {
        switch (command) {
            case 'add':
                result.push(counter);
                break;
            case 'remove':
                result.pop();
                break;
        }
        counter++;
    });

    console.log(result.length == 0 ? 'Empty' : result.join('\r\n'));
}
