
export default function SongTab ({index, song}){
    return (
        <div className="border-b">
            <span className="text-xl font-normal p-2 text-gray-500">{index}.</span>
            <span className="text-lg font-semibold">{song.name}</span>
            <span className="text-lg float-right text-gray-500">{Math.round(song.duration * 100) / 100}</span>
        </div>
    )

}