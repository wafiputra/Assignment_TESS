import React from 'react'
import { useState } from 'react'
import { Link } from 'react-router-dom'
import Validation from '../LoginValidation';

function Login() {
    // const [email, setEmail] = useState('')
    // const [password, setPassword] = useState('')
	const [values, setValues] = useState({
		email : '',
		password : ''
	})
	const [errors, setErrors] = useState({})
	const handleInput = (event) => {
		setValues(prev => ({...prev, [event.target.name] : [event.target.values]}))
	}
	const handleSubmit = (event) =>{
		event.preventDefault();
		setErrors(Validation(values));
	}

    // function handleSubmit(event) {
    //     event.preventDefault();
	// 	if (email === "test@mail.com" && password === "12345") {
	// 		console.log('Login Success')
	// 	}else{
	// 		console.log('Login Failed')
	// 	}
    // }
	return (
		<div className='flex justify-center items-center h-screen'>
			<div className="w-full max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow sm:p-6 md:p-8">
				<form
					className="space-y-6"
					onSubmit={handleSubmit}
				>
					<h5 className="text-xl font-medium text-gray-900">
						Sign in Page
					</h5>
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
                            onChange={handleInput}
						/>
						{errors.email && <span className='text-red-500'>{errors.email}</span> }
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
                            onChange={handleInput}
							/>
							{errors.password && <span className='text-red-500'>{errors.password}</span> }
					</div>
					<button
						type="submit"
						className="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
					>
						Login to your account
					</button>
					<div className="text-sm font-medium text-gray-500">
						Not registered?{' '}
						<Link to="/signup" className="text-blue-700 hover:underline">
						Create account
						</Link>
					</div>
				</form>
			</div>
		</div>
	)
}

export default Login
