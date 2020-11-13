function attachEvents() {
    const baseUrl = `https://blog-apps-c12bf.firebaseio.com/`;
    let loadPostBtn = document.getElementById('btnLoadPosts');
    let viewBtn = document.getElementById('btnViewPost');

    let posts = document.getElementById('posts');
    let postTitleEl = document.getElementById('post-title');
    let postBodyEl = document.getElementById('post-body');
    let postCommentsEl = document.getElementById('post-comments');

    loadPostBtn.addEventListener('click', () => {
        fetch(baseUrl + `posts.json`)
            .then(response => response.json())
            .then(data => {
                let options = Object.keys(data).map(key => `<option value="${key}">${data[key].title}</option>`).join('');
                posts.innerHTML = options;
            });
    });

    viewBtn.addEventListener('click', () => {
        fetch(baseUrl + `/posts/${posts.value}.json/`)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                postTitleEl.textContent = data.title;
                postBodyEl.textContent = data.body;
                data.comments.map(cm => postCommentsEl.innerHTML += `<li>${cm.text}</li>`).join('');
            });

    });
}
attachEvents();