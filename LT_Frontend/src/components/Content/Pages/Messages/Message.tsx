import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import Loading from "../../../Loading";
import { Message } from '../../../../server/api/messagedata/model/message';

interface messageType {
  id: string,
  userId: string,
  body: string,
  createdDate: Date
}

function Messages() {
  getMessages();
  const [messages, setMessages] =useState<messageType[]>([])
  const { user } = useAuth0();
  const [messageIdToDelete, setDelete] = useState({
    id: ""
  })

  const [data, setData] = useState({
    userId: "",
    body: ""
  });


  const handledeleteChange = (e: { target: { value: any; name: any; }; }) =>{
    const value = e.target.value;
    setDelete({
      ...messageIdToDelete,
      [e.target.name]: value
    });
  };

  const handlePostChange = (e: { target: { value: any; name: any; }; }) => {
    const value = e.target.value;
    setData({
      ...data,
      [e.target.name]: value
    });
  };

  const handleDeleteSubmit = (e: { preventDefault: () => void; }) =>{
    e.preventDefault();
    const deleteData = {
      id: messageIdToDelete.id
    };
    axios.get(`https://localhost:7202/message/delete?id=${deleteData.id}`).then((response)=> {
      console.log(response);
    }).catch((error) =>{
      console.log(error);
    });
    window.location.reload();
  }

  const handlePostSubmit = (e: { preventDefault: () => void; }) => {
    e.preventDefault();
    const postData = {
      userId: data.userId,
      body: data.body
    };
    axios.post('https://localhost:7202/message/add', postData).then((response)=> {
    });
    window.location.reload();
  }

    function getMessages(){
      useEffect(() => {
        axios.get('https://localhost:7202/message/getall').then((response)=>{
          setMessages(response.data)
        }).catch((error)=>{
          alert(error)
        })
      },[])
    }

  return (
    <div><h2 className='table table-dark'>Messages</h2>
    <table>
      <thead className='table table-dark'>
        <tr>
          <th>MessageId</th>
          <th>UserId</th>
          <th>Message  </th>
        </tr>        
      </thead>
      <tbody className='table table-dark'>
      {messages.map((message)=>( 
      <tr key={message.id}>
        <td>{message.id}</td>
        <td>{message.userId}</td>
        <td>{message.body}</td>
      </tr>
      ))}
      </tbody>
    </table><br/><br/><br/>

    <h2 className='table table-dark'>Add Message</h2><br/>
    <form onSubmit={handlePostSubmit}> 
      <label htmlFor='userId'>
        UserId
      <input type='userId' name='userId' value={data.userId} onChange={handlePostChange}/>
      </label>
      <label htmlFor='body'>
        Message
      <input type='body' name='body' value={data.body} onChange={handlePostChange}/>
      </label>
      <button type='submit'>Submit</button>
    </form> <br/><br/><br/>

    <h2 className='table table-dark'>Delete Message</h2>
    <form onSubmit={handleDeleteSubmit}>
      <label htmlFor='id'>
        MessageId
        <input type='id' name='id' value={messageIdToDelete.id} onChange={handledeleteChange}/>
      </label>
        <button type='submit'>Delete</button>
    </form>
    </div>
    
  );
}


export default withAuthenticationRequired(Messages, {
  onRedirecting: () => <Loading></Loading>,
});
