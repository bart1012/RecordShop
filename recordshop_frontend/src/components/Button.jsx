export default function Button ({text, onClickFunction}){
    return(
    <button class="bg-gray-500 hover:bg-gray-700 w-[20rem] text-white font-bold py-2 px-4 rounded-full" onClick={onClickFunction}>
        {text}
    </button>)
}