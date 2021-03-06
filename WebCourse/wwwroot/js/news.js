$(document).ready(() => {
    getNews(1);
});

function getNews(page){
    axios.get('/api/news/' + page)
    .then(function (response) {
        let news = response.data.news;

        let output = `
            <h2>Новости</h2>
            <hr>
        `;
        $.each(news, (index, singleNews) =>{
            let date = new Date(singleNews.publicationDateTime);
            output += `
            <h2><a href="#" onclick="getSingleNews(event, ${singleNews.newsID}, ${response.data.currentPage})">${singleNews.title}</a></h2>

            <div class="container-fluid">
                <span class="fa fa-calendar pull-left"> ${date.toLocaleDateString()}</span>
                &nbsp;&nbsp;<span class="fa fa-clock-o pull-left"> ${date.toLocaleTimeString()}</span>
            </div>
            ${singleNews.preview}
            <p class="text-right">
                <a href="#" onclick="getSingleNews(event, ${singleNews.newsID}, ${response.data.currentPage})">Подробнее...</a>
            </p>
            <hr>
            `;
        });
        output += `<ul class="pager">`
        if(response.data.currentPage > 1){
            output += `
                <li class="previous"><a onclick='getNews(${response.data.currentPage-1})'>&larr; Предыдущая</a></li>
            `;
        }
        if(response.data.currentPage < response.data.totalItems / response.data.itemsPerPage){
            output += `
                <li class="next"><a onclick='getNews(${response.data.currentPage+1})'>Следующая &rarr;</a></li>
            `;
        }

        $('#News').html(output);
    })
    .catch(function (error) {
        console.log(error);
    });
}

function getSingleNews(e, id, page){
    e.preventDefault();
    axios.get('/api/news/SingleNews/' + id)
    .then(function (response) {
        let date = new Date(response.data.publicationDateTime);
        let output = `
            <h2><a href="#" onclick="getSingleNews(event, ${id}, ${page})">${response.data.title}</a></h2>

            <div class="container-fluid">
                <span class="fa fa-calendar pull-left"> ${date.toLocaleDateString()}</span>
                &nbsp;&nbsp;<span class="fa fa-clock-o pull-left"> ${date.toLocaleTimeString()}</span>
            </div>
            <hr>
            ${response.data.content}
            <hr>
            <ul class="pager">
                <li class="previous"><a href="#" onclick='getNews(${page}, event)'>&larr; Назад</a></li>
            </ul>	
            `;
        $('#News').html(output);
    })
    .catch(function (error) {
        console.log(error);
    });
}
