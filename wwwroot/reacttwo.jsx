class Playersrr extends React.Component {
    
    constructor(props) {
       super(props);
        dotnetify.hubServerUrl = "http://localhost:5000";
        this.state = dotnetify.react.connect("Players", this);
        this.state = { PlayerList: []}
        // Set up function to dispatch state to the back-end with optimistic update.
        this.dispatch = state => this.vm.$dispatch(state);
        this.dispatchState = state => {
            this.setState(state);
            this.vm.$dispatch(state);
      }
    }
      
    render() {
        console.log("LIST", this.state.PlayerList)
        this.state.PlayerList.forEach(function(element) {
            console.log(element)
        }, this);
        var players = this.state.PlayerList.map((player) => {
            return (
                <Player
                name={player.first_name}
                />
            );
        }, this);  
       return (
           <div id="players">
            {players}
           </div>
        // <div className="table-responsive">
        //     <table className="table table-striped table-hover">
        //         <thead>
        //             <tr>
        //                 <th>Name</th>
        //                 <th>Pricechange</th>
        //             </tr>
        //         </thead>
        //         <tbody>
        //         {console.log(this.state.PlayerList)}
        //         {console.log(this.state.TEST)}
        //         {this.state.PlayerList.map((person, index) => (
        //             <p>Hello, {person.first_name}!</p>
        //         ))}
        //             <tr className="">
        //                 <td>player.first_name player.second_name</td>
        //                 <td>player.cost_change_event</td>
        //             </tr>
        //         </tbody>
        //     </table>
        // </div>
       );
    }
 };
 
 ReactDOM.render(
       <Playersrr />,
   document.getElementById('Content')
 );