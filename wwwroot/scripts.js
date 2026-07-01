const API_URL = "/api/ShortCutUrls";

const urlInput = document.getElementById("urlInput");
const shortenButton = document.getElementById("shortenButton");
const loading = document.getElementById("loading");
const result = document.getElementById("result");
const shortUrl = document.getElementById("shortUrl");
const copyButton = document.getElementById("copyButton");
const error = document.getElementById("error");
document.addEventListener("DOMContentLoaded", () => {
    shortenButton.addEventListener("click", async () => {

        const url = urlInput.value.trim();

        error.classList.add("hidden");
        result.classList.add("hidden");

        if (url === "") {
            error.textContent = "Digite uma URL.";
            error.classList.remove("hidden");
            return;
        }

        loading.classList.remove("hidden");

        try {

            const response = await fetch(API_URL, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    url: url
                })
            });

            if (!response.ok) {
                const message = await response.text();
                throw new Error(message);
            }

            const data = await response.json();

            shortUrl.value = data.shortUrl;

            result.classList.remove("hidden");

        } catch (err) {

            error.textContent = err.message;
            error.classList.remove("hidden");

        } finally {

            loading.classList.add("hidden");

        }

    });

    copyButton.addEventListener("click", async () => {

        try {

            await navigator.clipboard.writeText(shortUrl.value);

            copyButton.textContent = "Copiado!";

            setTimeout(() => {
                copyButton.textContent = "Copiar URL";
            }, 2000);

        } catch {

            alert("Não foi possível copiar a URL.");

        }

    });

    urlInput.addEventListener("keydown", (event) => {

        if (event.key === "Enter") {
            shortenButton.click();
        }

    });

});