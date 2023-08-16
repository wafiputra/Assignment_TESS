import React from 'react'
import { useState } from 'react'
import { Link } from 'react-router-dom'

function Signup() {
    const [fName, setFname]= useState('')
    const [lName, setLname]= useState('')
    const [email, setEmail]= useState('')
    const [password, setPassword]= useState('')
    const [rPassword, setRpassword]= useState('')

    function handleSubmit(){

    }
	return (
		<div className="flex justify-center items-center h-screen">
			<div className="w-full max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow sm:p-6 md:p-8">
				<form
					className="space-y-6"
					onSubmit={handleSubmit}
				>
					<h5 className="text-xl font-medium text-gray-900">Sign up Page</h5>
					<div>
						<label
							htmlFor="fName"
							className="block mb-2 text-sm font-medium text-gray-900"
						>
							First Name
						</label>
						<input
							type="text"
							name="fName"
							id="fName"
							className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
							placeholder="Your First Name"
							required
							onChange={(e) => setFname(e.target.value)}
						/>
					</div>
					<div>
						<label
							htmlFor="lName"
							className="block mb-2 text-sm font-medium text-gray-900"
						>
							Last Name
						</label>
						<input
							type="text"
							name="lName"
							id="lName"
							className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
							placeholder="Your Last Name"
							required
							onChange={(e) => setLname(e.target.value)}
						/>
					</div>
					<div>
						<label
							htmlFor="email"
							className="block mb-2 text-sm font-medium text-gray-900"
						>
							Your email
						</label>
						<input
							type="email"
							name="email"
							id="email"
							className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
							placeholder="name@company.com"
							required
							onChange={(e) => setEmail(e.target.value)}
						/>
					</div>
					<div>
						<label
							htmlFor="password"
							className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
						>
							Your password
						</label>
						<input
							type="password"
							name="password"
							id="password"
							placeholder="••••••••"
							className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
							required
							onChange={(e) => setPassword(e.target.value)}
						/>
					</div>
					<div>
						<label
							htmlFor="rpassword"
							className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
						>
							Repeat password
						</label>
						<input
							type="password"
							name="rpassword"
							id="rpassword"
							placeholder="••••••••"
							className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
							required
							onChange={(e) => setRpassword(e.target.value)}
						/>
					</div>
					<button
						type="submit"
						className="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
					>
						Create account
					</button>
					<div className="text-sm font-medium text-gray-500">
						Have Account?{' '}
						<Link
							to="/"
							className="text-blue-700 hover:underline"
						>
							Sign in
						</Link>
					</div>
				</form>
			</div>
		</div>
	)
}

export default Signup
