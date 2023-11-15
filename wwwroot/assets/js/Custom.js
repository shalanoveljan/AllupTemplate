$(document).ready(function () {
    $('#searchBtn').click(function (e) {
        e.preventDefault();

        let searchInput = $('#searchInput').val();
        let categoryId = $('#searchCategory').val();

        fetch('/shop/search?categoryId=' + categoryId + '&search=' + searchInput)
            .then(res => res.json())
            .then(data => {
                console.log(data)
            })

    })

})
    console.log("salam");

