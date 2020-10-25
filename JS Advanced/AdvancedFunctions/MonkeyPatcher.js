solution = (() => {
    const commands = {
        upvote: (post) => post.upvotes++,
        downvote: (post) => post.downvotes++,
        score: (post) => {
            let { upvotes, downvotes } = post;
            let total = upvotes + downvotes;
            let balance = upvotes - downvotes;

            if (total > 50) {
                obfuscated = Math.ceil(0.25 * Math.max(upvotes, downvotes));
                upvotes += obfuscated;
                downvotes += obfuscated;
            }

            let rating = 'new';

            if (total < 10) {
                rating ='new';
            }
            else if (upvotes > total * 0.66) {
                rating = 'hot';
            } else if (balance >= 0 && (upvotes > 100 || downvotes > 100)) {
                rating = 'controversial';
            } else if (balance < 0) {
                rating = 'unpopular';
            } 
            
            return [upvotes, downvotes, balance, rating];
        }
    };

    return {call: (post, command) => commands[command](post)};
})()

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
solution.call(post, 'score'); // [127, 127, 0, 'controversial']
solution.call(post, 'downvote'); // (executed 50 times)
score = solution.call(post, 'score');     
