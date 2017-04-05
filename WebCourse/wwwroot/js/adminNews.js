$(document).ready(() => {
    getNews("all");
    $("#patternInput").keyup(function() {
        getNews($("#patternInput").val());
    });
    
});

function getNews(pattern){
    if(pattern == "")
        pattern = "all";
    axios.get('/api/news/searchNews/' + pattern)
    .then(function (response) {
        let news = response.data.news;
        let output = `<table class="table table-striped table-hover">`;
        if(news.length == 0){
            output += `
                <tr>
                    <th>Новостей с таким названием нету</th>
                </tr>
            `;
        } else {
            output += `
            <tr>
                        <th>Название</th>
                        <th>Опубликована</th>
                        <th>Время создания</th>
                        <th></th>
            </tr>
            `;
            $.each(news, (index, singleNews) =>{
            let date = new Date(singleNews.publicationDateTime);
            output += `

                      <tr>
                                  
                        <td>${singleNews.title}</td>
                        <td><span class="glyphicon ${singleNews.published ? "glyphicon-ok" : "glyphicon-remove"}" aria-hidden="true"></span></td>
                        <td>${date.toLocaleString()}</td>
                        <td>
                        <form action="DeleteNews" method="POST">
                        <a class="btn btn-default" href="News/Edit/${singleNews.newsID}">Изменить</a>
                        <input type="hidden" name="id" value="${singleNews.newsID}" />
                        <button class="btn btn-danger" type="Submit">Удалить</button>
                        </form>
                        </td>
                      </tr>
            
            `;
        });
    }
    output +=
    `
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td><a class="btn btn-primary" href="News/Create">Создать новость</a></td>
    </tr>
    </table>`;
    $("#newsTable").html(output);
                $("#newsTable").html(output);
    })
    .catch(function (error) {
        console.log(error);
    });
}