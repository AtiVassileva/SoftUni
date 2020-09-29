function Cook(params){
    let number = Number(params[0]);

    for (let i = 1; i < params.length; i++) {
        let currentOperation = params[i];

        switch (currentOperation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
                case 'spice':
                    number++;
                    break;
                    case 'bake':
                        number *= 3;
                        break;
                        case 'fillet':
                            number -= number * 0.2;
                            break;
        }
        console.log(number);
    }
}
