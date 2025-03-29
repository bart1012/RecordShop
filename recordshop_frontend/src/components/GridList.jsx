const musicGenres = [
    "Rock",
    "Pop",
    "Hip-Hop",
    "Jazz",
    "Classical",
    "Electronic",
    "Reggae",
    "Blues",
    "Country",
    "Metal"
  ];

const GenreList = () => {
    return(
        <div className="grid grid-cols-2 gap-3">
            {musicGenres.map( (genre) => 
                <div className="bg-red-400 h-20 w-auto">{genre}</div>
            )}
   
        </div>
    )
}

export default GenreList