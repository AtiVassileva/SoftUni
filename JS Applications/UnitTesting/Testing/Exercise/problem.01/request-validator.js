function solve(httpRequest){
    let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];

    if (!httpRequest.hasOwnProperty('method') || !methods.includes(httpRequest.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    let uriRegex = /^([a-zA-Z0-9.]+)$|\*/g;
    if (!httpRequest.hasOwnProperty('uri') || !httpRequest.uri.match(uriRegex)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    if (!httpRequest.hasOwnProperty('version') || !versions.includes(httpRequest.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    let messageReg = /^[^<>\\&'"]*$/g;
    if (!httpRequest.hasOwnProperty('message') || !httpRequest.message.match(messageReg)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpRequest;
}