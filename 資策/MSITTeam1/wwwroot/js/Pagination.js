function initPagination(pageEle, showItem, paginationTarget) {
    let pageLength = $(pageEle).length
    let showItemLength = showItem
    let showPage = Math.ceil(pageLength / showItemLength)

    $(paginationTarget).twbsPagination({
        totalPages: showPage,
        visiblePages: 5,
        first: "<<",
        prev: "<",
        next: ">",
        last: ">>",
        nextClass: "page-item pageColor",
        prevClass: "page-item pageColor",
        lastClass: "page-item pageColor last",
        firstClass: "page-item pageColor first",
        pageClass: "page-item pageColor",
        activeClass: "page-item pageBG",
        onPageClick: function (event, page) {
        }
    }).on('page', function (event, page) {
        $(pageEle).fadeOut(200)
        let start = (page - 1) * showItemLength
        let end = (page - 1) * showItemLength + showItemLength - 1
        $(pageEle).each((index, item) => {
            if (index >= start && index <= end) {
                $(item).fadeIn(600)
            }
        })
    });

    $(pageEle).hide()

    pageLength <= showItemLength && $(pageEle).fadeIn(600)
    if (pageLength > showItemLength) {
        $(pageEle).each((index, item) => {
            if (index < showItemLength) {
                $(item).fadeIn(600)
            }
        })
    }
}