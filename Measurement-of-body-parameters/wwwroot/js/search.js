
const CreatSearch = (OpenSearch, SearchDiv, SearchName) => {
    const SearchInput = SearchDiv.querySelector("input");
    let isOpenSearch = false;

    OpenSearch.addEventListener("click", () => {
        if (isOpenSearch) {
            SearchDiv.style.display = "none";
        } else {
            SearchDiv.style.display = "block";
        }
        isOpenSearch = !isOpenSearch;

        SearchInput.focus();
    });


    document.addEventListener("click", (event) => {
        if (event.target !== OpenSearch && event.target !== SearchDiv && event.target !== SearchInput && event.target !== OpenSearch.querySelector("span")) {
            SearchDiv.style.display = "none";
            isOpenSearch = false;
        }
    });

    SearchInput.addEventListener("input", () => {
        SearchOnly(SearchInput.value);
    });

    const SearchOnly = (search) => {
        SearchName.forEach((e, i) => {

            let mainString = e.getAttribute('string');
            e.innerHTML = mainString;

            if (mainString.toLowerCase().includes(search.toLowerCase())) {
                e.parentElement.style.display = "table-row";

                let startIndex = mainString.indexOf(search);
                let extractedText = mainString.substring(startIndex, startIndex + search.length);
                let textBefore = mainString.substring(0, startIndex);
                let textAfter = mainString.substring(startIndex + search.length);

                let newText = textBefore + `<span class="bg-warning">` + extractedText + `</span>` + textAfter;
                e.innerHTML = newText;
            } else {
                e.parentElement.style.display = "none";
            }
        });
    }
}

//Tests, Device
CreatSearch(document.querySelector("#OpenSearch-Name"), document.querySelector("#SearchDiv-Name"), document.querySelectorAll(".SearchDisplay-Name"));

//Tests
try {
    CreatSearch(document.querySelector("#OpenSearch-Description"), document.querySelector("#SearchDiv-Description"), document.querySelectorAll(".SearchDisplay-Description"));
} catch { }