function createArticle() {
	let titleElement = document.getElementById("createTitle");
	let contentElement = document.getElementById("createContent");

	let headingElement = document.createElement('h3');
	headingElement.innerHTML = titleElement.value;
	titleElement.value = '';

	let paragraphElement = document.createElement('p');
	paragraphElement.innerHTML = contentElement.value;
	contentElement.value = '';

	let articleElement = document.createElement('article');
	articleElement.appendChild(headingElement);
	articleElement.appendChild(paragraphElement);

	let articlesElements = document.getElementById('articles');
	articlesElements.appendChild(articleElement);

	
}