import LinkList from "../components/LinkList"

const Account = () => {
    return(
        <>
        <LinkList title="Orders">
            <span>Order History</span>
            <span>Returns</span>
        </LinkList>
        <LinkList title="Account Settings">
            <span>Billing Information</span>
            <span>Manage Account Details</span>
        </LinkList>
        </>
    )
}

export default Account