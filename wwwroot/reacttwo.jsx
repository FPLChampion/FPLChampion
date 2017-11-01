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
        var playerTable = this.state.PlayerList.map((player) => {
            return (
                <div className="table-responsive">
                    <table className="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Pricechange</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr className="" key={player.id} name={player.first_name}>
                                <td>{player.first_name} {player.second_name}</td>
                                <td>{player.cost_change_event}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            );
        }, this);  
       return (
           <div>{playerTable}</div>
        );
       
        //     <table className="table table-striped table-hover">
        //         <thead>
        //             <tr>
        //                 <th>Name</th>
        //                 <th>Pricechange</th>
        //             </tr>
        //         </thead>
        //         <tbody>
        //             <tr className="">
        //                 <td>player.first_name player.second_name</td>
        //                 <td>player.cost_change_event</td>
        //             </tr>
        //         </tbody>
        //     </table>
    }
 };
 
 ReactDOM.render(
       <Playersrr />,
   document.getElementById('Content')
 );