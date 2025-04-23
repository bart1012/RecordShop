export default function Button ({text, onClickFunction}){
    return(
    <button class="bg-gray-500 hover:bg-gray-700 w-full text-white font-bold py-3 px-4 rounded-full" onClick={onClickFunction}>
        {text}
    </button>)
}