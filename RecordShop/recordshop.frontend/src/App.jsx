import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import AlbumList from './components/albumList.tsx'
function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
              <AlbumList></AlbumList>
      </div>

      <div className="card">
       
      </div>
    
    </>
  )
}

export default App
