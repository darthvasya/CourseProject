$(document).ready(() => {
    getStats();
});

function getStats(){
    axios.get('/api/stats/')
    .then(function (response) {
        let stats = response.data.stats;
        
        let output = `
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-user" aria-hidden="true"></span> ${stats.usersCount}</h2>
                    <h4>Пользователи</h4>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> ${stats.newsCount}</h2>
                    <h4>Новости</h4>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-scale" aria-hidden="true"></span> ${stats.productsCount}</h2>
                    <h4>Продукты</h4>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-briefcase" aria-hidden="true"></span> ${stats.companiesCount}</h2>
                    <h4>Предприятия</h4>
                  </div>
                </div>
                
        `;
        $('#stats').html(output);
    })
    .catch(function (error) {
        console.log(error);
    });
}