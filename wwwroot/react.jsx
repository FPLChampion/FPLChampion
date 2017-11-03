class PlayersInTeamTable extends React.Component {
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
       return (
           <PlayerTable data={this.state.PlayerList}/>
        );
    }
 };
 
 class PlayerTable extends React.Component {
    render() {
        const isLoading = () => {
            if(!this.props.data){
                return <h1>LOADING</h1>
            } else {
                return <h1>DONE LOADING</h1>
            }
        }
        const playerRows = this.props.data.map(player => {
            return <PlayerRow data={player} key={player.id}/>
        });
        return (
            <div className="table-responsive">
            {isLoading()}
                <table className="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Pricechange</th>
                        </tr>
                    </thead>
                    <tbody>
                        {playerRows}
                    </tbody>
                </table>
            </div>
        );
    }
}

class PlayerRow extends React.Component {
    render() {
        const player = this.props.data;
        return (
            <tr className="">
                <td>{player.first_name} {player.second_name}</td>
                <td>{player.cost_change_event}</td>
            </tr>
        );
    }
}

 ReactDOM.render(
       <PlayersInTeamTable/>,
   document.getElementById('Content')
 );