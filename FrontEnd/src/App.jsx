import { useState } from 'react'
import './App.css'
import Login from './pages/Login'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Signup from './pages/Signup'

function App() {
	const [count, setCount] = useState(0)

	return (
		<BrowserRouter>
			<Routes>
				<Route
					path="/"
					element={<Login />}
				></Route>
				<Route
					path="/signup"
					element={<Signup />}
				></Route>
			</Routes>
		</BrowserRouter>
	)
}

export default App
