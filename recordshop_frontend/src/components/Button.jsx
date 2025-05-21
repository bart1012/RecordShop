export default function Button ({text, onClickFunction, colour="gray", btnType}){
    return(
    <button type={btnType} class={"cursor-pointer w-full font-bold py-3 px-4 rounded-full " + (colour === "gray" ? "bg-gray-500 hover:bg-gray-700 text-white" : "bg-white hover:bg-gray-100 border border-[#2e2e2e] text-gray-500")} onClick={onClickFunction}>
        {text}
    </button>)
}