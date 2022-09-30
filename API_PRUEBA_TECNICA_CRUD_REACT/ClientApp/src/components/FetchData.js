
export const FetchData = async () => {
    try {
        const response = await fetch("api/contactos/ListData");
        const data = await response.json();
        return data;
    } catch (e) {
        console.log(e)
    }
}
