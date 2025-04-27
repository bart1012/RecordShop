import Button from "../components/Button";

const Registration = () => {
    return <main className="w-1/4  min-h-screen flex m-auto items-center align-center"> 
        <section className="w-full m-auto">
            <h1 className="text-3xl  font-semibold mb-5">Create an account</h1>
            <div className="flex flex-row mb-2 text-md text-gray-600">
                <span className="mr-5">Location: United Kingdom</span>
                <span className="underline">Change</span>
            </div>
            <input type="text" id="emailInput" name="email" placeholder="Email" className="rounded-md w-full"/>
            <div className="mt-2 mb-10">
                <p className="text-sm text-gray-600">
                    By continuing, you agree to not much and you confirm you have read some books in the past.
                </p>
            </div>
            <Button text={"Continue"}></Button>
        </section>      
    </main>
}

export default Registration;