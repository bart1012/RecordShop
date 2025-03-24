import * as React from "react";
import { fetchAllAlbums } from "../service/apiService";
import { useState, useEffect } from 'react';

function AlbumList() {

    const [data, setData] = useState(null);
    const arr = [1, 2, 4];

    async function fetchData() {

        try {
            let apiData = await fetchAllAlbums();
            setData(apiData);
        } catch (error) {
            console.error('Error fetching data', error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    return   (
        <div>
            {data ? (
                <ul>
                    {data.map((entry) => (
                        <li key={entry.id}>
                            {entry.name}
                        </li>
                    )) }
                </ul>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );  

}

export default AlbumList;