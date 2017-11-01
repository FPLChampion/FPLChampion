var Players = React.createClass({
    getInitialState() {
       dotnetify.react.connect("Players", this);
       return { PlayersList: [] };
       // The VM's initial state was generated server-side and included with the JSX.
    },
    render() {
       return (
          <div class="table-responsive">
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Pricechange</th>
                    </tr>
                </thead>
                <tbody>
                {console.log(this)}
                {console.log(this.state)}
                {console.log("list", this.state.PlayerList)}
                    <tr class="">
                        <td>player.first_name player.second_name</td>
                        <td>player.cost_change_event</td>
                    </tr>
                </tbody>
            </table>
        </div>
       );
    }
 });
 
 ReactDOM.render(
       <Players />,
   document.getElementById('Content')
 );